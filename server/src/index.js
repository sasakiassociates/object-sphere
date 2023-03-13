require("dotenv").config();

const {ApolloServer} = require("apollo-server");
const typeDefs = require("./schema");
const resolvers = require("./resolvers");
const ViewObjectAPI = require("./datasources/ViewObjectAPI");
const NudgeAPI = require("./datasources/NudgeAPI");

const mockUp = {
    ResultCloud: () => ({
        id: () => "12345",
        points: () =>
            Array.form({length: 100}, () => ({
                CloudPoint: () => ({
                        x: () => 1,
                        y: () => 1,
                        z: () => 1,
                        meta: () => "hi there",
                    }
                )
            })),
        data: () => ({
            ResultCloudData: () => ({
                option: () => "EXISTING",
                values: () => Array.from({length: 100}, () => Math.floor(Math.random() * 40)),
            })
        })

    }),

}

const server = new ApolloServer({
    typeDefs,
    resolvers,
    mocks: mockUp,
    dataSources: () => {
        return {
            viewObjectAPI: new ViewObjectAPI(),
            nudgeAPI : new NudgeAPI(),
        }
    }
});


server.listen().then(() => {
    console.log(`
    Server is running!
    Listening on port 4000
    Explore at https://studio.apollographql.com/sandbox
  `);
});