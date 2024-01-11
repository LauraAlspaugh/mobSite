<template>
    <div class="container-fluid">
        <section v-if="project" class="row justify-content-start">
            <div class="col-3">
                <img :src="project.img" alt="project image">
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


<style lang="scss" scoped></style>