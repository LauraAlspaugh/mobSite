import { AppState } from "../AppState.js"
import { Project } from "../models/Project.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProjectsService{
async getProjects(){
    const res = await api.get('api/projects')
    logger.log("getting projects", res.data)
    AppState.projects = res.data.map(pojo => new Project(pojo))
}
}
export const projectsService = new ProjectsService()