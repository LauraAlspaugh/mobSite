import { AppState } from "../AppState.js"
import { Post } from "../models/Post.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class PostsService{
    async createPost(postData){
        const res = await api.post('api/posts', postData)
        logger.log('creating post!', res.data)
        const newPost = new Post(res.data)
        AppState.posts.push(newPost)
        return newPost
    }
}
export const postsService = new PostsService()