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
        <section class="row tier-list text-white">
            <div v-for="tier in tiers" :key="tier.id" class="col-3 p-2  tier-content">
                <div class=" d-flex justify-content-between">
                    <p>{{ tier.name }}</p>
                    <p>${{ tier.cost }}</p>
                    <p>{{ 0 }}<i class="mdi mdi-account"></i></p>
                </div>
                <p class="text-center">Thank you for your support, every dollar counts!</p>

            </div>

        </section>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { projectsService } from '../services/ProjectsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
        onMounted(() => {
            getProjectById()
            getTiersByProjectId()
        })
        const route = useRoute();
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
            project: computed(() => AppState.activeProject),
            tiers: computed(() => AppState.tiers)
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
    left: 145px;
}

.tier-content {
    background-color: #3F7D75;
    margin: 5px;
    border-radius: 7px;
    width: 220px;
    height: 130px;
    box-shadow: 3px 2px 3px gray;

}
</style>