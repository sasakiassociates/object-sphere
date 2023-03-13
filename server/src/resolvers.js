const resolvers = {
    Query: {
        // some info on returning
        data: (_, __, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject();
        },
        result: (_, __, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject();
        },
        study:({streamId, objectId}, _, {dataSources})=>{
            return dataSources.viewObjectAPI.getObject(streamId, objectId);
        }
    },
    ResultCloudData: {
        values: ({streamId, objectId}, _, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject(streamId, objectId)
        }
    }
};


module.exports = resolvers;