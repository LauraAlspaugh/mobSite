<template>
    <div class="project-card d-flex">
        <router-link :to="{ name: 'Project', params: { projectId: projectProp.id } }">
            <div class="col-6">
                <img class="img-fluid" :src="projectProp.img" alt="project image">

            </div>
            <div class="col-6">
                <p class="m-2 fs-4 project-name">{{ projectProp.name }}</p>
                <p class="m-2">{{ projectProp.description }}</p>

            </div>

        </router-link>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Project } from '../models/Project.js';
export default {
    props: { projectProp: { type: Project, required: true } },
    setup() {
        return {
            projects: computed(() => AppState.projects)
        }
    }
};
</script>


<style lang="scss" scoped>
.project-card {
    background-color: white;
    border-radius: 7px;
    margin-bottom: 7px;
    box-shadow: 3px 2px 3px gray;
}

img {
    width: 100%;
    border-radius: 7px;
    height: 250px;
    object-fit: cover;
}

.project-name {
    color: #3F7D75;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
</style>