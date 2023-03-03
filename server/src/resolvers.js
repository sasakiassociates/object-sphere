const resolvers = {
    Query: {
        // some info on returning
        data: (_, __, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject();
        },
        result: (_, __, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject();
        }
    },
    ResultCloudData: {
        values: ({streamId, objectId}, _, {dataSources}) => {
            return dataSources.viewObjectAPI.getObject(streamId, objectId)
        }
    }
};


module.exports = resolvers;