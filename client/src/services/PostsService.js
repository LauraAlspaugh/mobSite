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
    async destroyPost(postId) {
        logger.log('deleting post with following id', postId)
        const res = await api.delete(`api/posts/${postId}`)
        logger.log('destroying post', res.data)
        const postIndex = AppState.posts.findIndex(post => post.id == postId)
        if (postIndex == -1) { throw new Error('No post found with this id') }
        AppState.posts.splice(postIndex, 1)
    }
}
export const postsService = new PostsService()