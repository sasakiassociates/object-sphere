const {RESTDataSource} = require("apollo-datasource-rest");

class ViewObjectAPI extends RESTDataSource {
    constructor() {
        super();
        this.baseURL = "https://speckle.xyz/api/"
    }

    getObject(streamId, objectId) {
        return this.get(`objects/${streamId}/${objectId}`)
    }

    getResult(objectId) {
        return this.get(`objects/`)
    }
}

module.exports = ViewObjectAPI;