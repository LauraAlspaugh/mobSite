<template>
  <div class="container-fluid">
    <section class="row justify-content-evenly">
      <div class="col-10 quote-title">
        <p class="fs-4 p-2 quote-content text-center mt-4">“It is literally true that you can succeed best and quickest by
          helping others
          to succeed.”
        </p>
        <p class="text-center">Mob supply is all about finding and helping those who inspire, create, build and entertain.
        </p>
        <p class="text-end p-2">-quote by Napoleon Hill</p>
      </div>
    </section>
    <section class="row justify-content-evenly mt-5">
      <div class="col-9">
        <div>
          <p class="text-white">What inspires you? </p>
          <form class="d-flex" @submit.prevent="getRecipesWithSearchQuery(editable)">

            <!-- <label for="recipeTitle" class="form-label"></label> -->
            <input v-model="editable" type="text" class="form-control" id="recipeTitle">
            <button class="search-box" type="submit">
              <p class="d-flex m-2">Search <i class="mdi mdi-magnify  "></i></p>
            </button>


          </form>
        </div>
      </div>
    </section>
    <section class="row justify-content-evenly mt-5">
      <div class="col-8" v-for="project in projects" :key="project.id">
        <ProjectCard :projectProp="project" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { projectsService } from '../services/ProjectsService.js';
import ProjectCard from '../components/ProjectCard.vue';

export default {
  setup() {
    onMounted(() => {
      getProjects();
    });
    async function getProjects() {
      try {
        await projectsService.getProjects();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      projects: computed(() => AppState.projects)
    };
  },
  components: { ProjectCard }
}
</script>

<style scoped lang="scss">
.quote-title {
  background-color: #E9C451;
  border-radius: 7px;
}

.quote-content {
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  font-weight: bold;
}

.project-place {
  background-color: gray;
  border-radius: 7px;
}

.search-box {
  border-radius: 5px;
  background-color: #1DA1F2;
  color: white;
}
</style>
