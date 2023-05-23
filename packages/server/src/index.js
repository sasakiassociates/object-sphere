import dotenv from 'dotenv';
dotenv.config();

import { ApolloServer} from '@apollo/server';
import { startStandaloneServer } from '@apollo/server/standalone';
import { makeExecutableSchema } from '@graphql-tools/schema';
import {loadFiles} from '@graphql-tools/load-files';

import RobinApi from './sources/RobinApi.js';

async function startServer(){

  const typeDefs = await loadFiles('src/schema/*.graphql');
  const resolvers =  await loadFiles('src/resolvers/*.js');

  const schema = makeExecutableSchema({
    typeDefs, 
    resolvers
  });

  
    const server = new ApolloServer({
      introspection: true,
      schema: schema
    });    

    const dataSources = {
      robinApi: new RobinApi({token: process.env.ROBIN_TOKEN})
      // contextApi: new ContextApi(),
    }

    const { url } = await startStandaloneServer(server, { 
        context: () => {return { dataSources};},
        listen: {port: 4000 }
      });
    console.log(`🚀  Server ready at: ${url}`);

  }

  startServer();
  