export class Project{
    constructor(data){
        this.id = data.id 
        this.name = data.name
        this.img = data.img
        this.description = data.description
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleDateString()
        this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
      }
}