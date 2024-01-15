import { AppState } from "../AppState.js"
import { Project } from "../models/Project.js"
import { Tier } from "../models/Tier.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProjectsService{
async getProjects(){
    const res = await api.get('api/projects')
    logger.log("getting projects", res.data)
    AppState.projects = res.data.map(pojo => new Project(pojo))
}
async getProjectById(projectId){
    AppState.activeProject = null
    const res = await api.get(`api/projects/${projectId}`)
    logger.log('getting project by id', res.data)
    AppState.activeProject = new Project(res.data)
    
    }
    async getTiersByProjectId(projectId){
        const res = await api.get(`api/projects/${projectId}/tiers`)
        logger.log('getting tiers by project id', res.data)
        AppState.tiers = res.data.map(pojo => new Tier(pojo))
    }
}
export const projectsService = new ProjectsService()