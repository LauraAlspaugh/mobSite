<template>
    <div class="container-fluid">
        <section v-if="project" class="row  p-5">
            <div class="col-2  m-1">
                <img class="img-fluid project-image" :src="project.img" alt="project image">
            </div>
            <div class="col-2  d-flex align-items-center">
                <p>{{ project.name }}</p>
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
        return {
            project: computed(() => AppState.activeProject)
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
</style>