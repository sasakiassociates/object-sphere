// parent, args, context, info
// parent= return value of the resolver for this fields parent(useful for chains)
// args= the provided fields provided in the query 
// context= an object shared across all resolve objects
// info= information of the current resolver state

const resolvers ={
    Query: {
    building: async (_, __, ___) => {
        return 123;
    }
}
};

export default resolvers;