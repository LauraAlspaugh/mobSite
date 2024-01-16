export class Post{
    constructor(data){
        this.id = data.id
        this.title = data.title
        this.body = data.body
         this.shortBody = data.body.slice(0, 400)
        this.img = data.img
        this.tierId= data.tierId
        this.projectId = data.projectId
        this.creator = data.creator
        this.creatorId = data.creatorId
    }
    get shortDescription() {
        return this.body.slice(0, 50)
    }
}