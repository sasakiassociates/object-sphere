// parent, args, context, info
// parent= return value of the resolver for this fields parent(useful for chains)
// args= the provided fields provided in the query 
// context= an object shared across all resolve objects
// info= information of the current resolver state

const resolvers ={
    // Location: {
    //     spaces: ({id}, _, {dataSources}) =>{
    //         return dataSources.robinApi.
    //     }
    // },
    Query: {
    auth: async (_, __, { dataSources }) => {
        return dataSources.robinApi.getAuth();
    },
    space: async (_, { id }, { dataSources }) => {
        return dataSources.robinApi.getSpace(id);
    },
    spaces: async (_, { id }, { dataSources }) => {
        return dataSources.robinApi.getSpaces(id);
    },
    location: async (_, { id }, { dataSources }) => {
        return dataSources.robinApi.getLocation(id);
    },
    organization: async (_, { id }, { dataSources }) => {
        return dataSources.robinApi.getOrganization(id);
    }
}
};

export default resolvers;