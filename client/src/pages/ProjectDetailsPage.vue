<template>
    <div class="container-fluid">
        <section v-if="project" class="row  p-5">
            <div class="col-2  m-1">
                <img class="img-fluid project-image" :src="project.img" alt="project image">
            </div>
            <div class="col-2 mt-3 text-white">
                <p>{{ project.name }}</p>
                <p>Funded since 2024</p>
                <p> 0 Mob Members</p>
            </div>
            <div class="col-4"></div>
            <div class="col-3  mt-5 text-end">
                <button class="rounded p-3 text-light support-button">See all Supporters</button>
            </div>
        </section>
        <section v-if="project" class="row justify-content-evenly">
            <div class="col-11 bg-white tier-page">
                <p class="fs-5 text-center p-3 tier-place">Tiers</p>
            </div>
        </section>
        <section class="row tier-list text-white bg-white">
            <div v-for="tier in tiers" :key="tier.id" class="col-3 p-2  tier-content ">
                <div class=" d-flex justify-content-between">
                    <p>{{ tier.name }}</p>
                    <p>${{ tier.cost }}</p>
                    <p>{{ 0 }}<i class="mdi mdi-account"></i></p>
                </div>
                <p class="text-center">Thank you for your support, every dollar counts!</p>
                <i class="mdi mdi-delete-forever fs-5 d-flex justify-content-center"></i>
            </div>

        </section>
        <section class="row justify-content-evenly">
            <div class="col-7 p-4 mt-3 mb-3 post-form">
                <p class="create-title">Create a post for your supporters.</p>
                <form @submit.prevent="createPost()">
                    <p class="fs-5"></p>
                    <div class="mb-1">
                        <label for="body" class="form-label"></label>
                        <textarea v-model="editable.body" type="text" required rows="3" class="form-control" id="body"
                            placeholder="Say something..."></textarea>
                    </div>
                    <div class="mb-1">
                        <label for="title" class="form-label"></label>
                        <input v-model="editable.title" type="text" required class="form-control" id="title"
                            placeholder="Title...">
                    </div>

                    <div class="mb-3">
                        <label for="imageUrl" class="form-label"></label>
                        <input v-model="editable.img" type="url" required class="form-control" id="imgUrl"
                            placeholder="Image Url...">
                    </div>
                    <button type="submit" class="btn btn-dark d-flex justify-content-end">Create!</button>
                </form>
            </div>
        </section>
        <section class="row justify-content-evenly">
            <div v-for="post in posts" :key="post.id" class="col-7 post-form p-0">
                <img class="img-fluid post-image" :src="post.img" alt="post image">
                <div class="d-flex">
                    <p class="fs-5 text-start p-3 mb-0">{{ post.title }}</p>
                    <i role="button" @click="destroyPost(post.id)" class="mdi mdi-delete-forever destroy-post fs-4 p-3"></i>
                </div>
                <p class="text-start p-3">{{ post.shortBody }}...</p>
            </div>
        </section>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { projectsService } from '../services/ProjectsService.js';
import { postsService } from '../services/PostsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
        onMounted(() => {
            getProjectById()
            getTiersByProjectId()
            getPostsByProjectId()
        })
        const route = useRoute();
        const editable = ref({})
        async function getProjectById() {
            try {
                const projectId = route.params.projectId;
                await projectsService.getProjectById(projectId);
            }
            catch (error) {
                logger.error(error);
                Pop.error(error);
            }
        }
        async function getPostsByProjectId() {
            try {
                const projectId = route.params.projectId
                await projectsService.getPostsByProjectId(projectId)
            } catch (error) {
                logger.error(error)
                Pop.error(error)

            }
        }
        async function getTiersByProjectId() {
            try {

                const projectId = route.params.projectId;
                await projectsService.getTiersByProjectId(projectId)
            } catch (error) {
                logger.error(error)
                Pop.error(error)
            }
        }
        return {
            editable,
            project: computed(() => AppState.activeProject),
            tiers: computed(() => AppState.tiers),
            posts: computed(() => AppState.posts),
            description: computed(() => AppState.posts.shortDescription),
            // shortBody: computed(() => AppState.posts.shortBody),
            async createPost() {
                try {
                    const postData = editable.value
                    postData.projectId = AppState.activeProject.id
                    const post = await postsService.createPost(postData)
                    Pop.success('Post Created!')
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            },
            async destroyPost(postId) {
                try {
                    if (await Pop.confirm('Are you sure you want to destroy this Post? ')) {

                        logger.log('deleting post!', postId);
                        await postsService.destroyPost(postId);
                    }
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.project-image {
    border-radius: 7px;
    height: 130px;
    object-fit: cover;
    position: center;
}

.tier-page {
    border-radius: 7px;
    height: 250px;
    box-shadow: 3px 2px 3px gray;
    position: relative;
}

.tier-place {
    color: #3F7D75;
    font-family: 'Courier New', Courier, monospace;
    font-weight: bold;
}

.support-button {
    background-color: #3F7D75;
}

.tier-list {
    position: absolute;
    bottom: 200px;
    left: 400px;
}

.tier-content {
    background-color: #3F7D75;
    margin: 5px;
    border-radius: 7px;
    width: 220px;
    height: 134x;
    box-shadow: 3px 2px 3px gray;

}

.post-form {
    border-radius: 7px;
    margin-bottom: 5px;
    background-color: #F4EFE9;
    box-shadow: 3px 2px 3px gray;
}

.create-title {
    color: #1DA1F2;
}

.post-image {
    width: 100%;
    height: 300px;
    position: center;
    object-fit: cover;
    border-radius: 7px;
}
</style>