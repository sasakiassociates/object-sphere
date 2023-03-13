const typeDefs = gql`

    type Query {
        "Grab all result clouds from a specific stream"
        results(streamId : ID!) : [ResultCloud]
        "Grab a specific result cloud from a specific stream type"
        result(id : ID!) : ResultCloud
        data(target : ID!, content : ID! ,type : ViewContentType!) : ResultCloudData
    }

    type Mutation{
        setResults(id : ID!) : SetResultsResponse!
        addResults(id : ID!) : SetResultsResponse!
    }

    """
    A set of statuses a Content type would utilize in a View Study
    """
    enum ViewContentType {
        "The potential content item used to gather the max amount of pixels in a view"
        TARGET
        "The main blocking content item that sets the study with a current condition value"
        EXISTING
        "Optional content items that gives studies the ability to have multiple scenarios"
        PROPOSED
    }
    
    "A simple object used for Sasaki projects"
    interface SasakiObject {
        "The id related to the reference object id"
        id: ID!
        "An optional name for the object"
        name : String
    }
    
    "A simple container object that is mainly used for acting as an anchor point for a specific workflow type"
    interface SasakiContainer{
        "The id related to the reference object id"
        id: ID!
        "An optional name for the object"
        name : String
        "The items it contains"
        data : [SasakiObject!]!
    }

    type ViewStudy implements SasakiContainer {
        "The id related to the reference object id"
        id: ID!
        "An optional name for the object"
        name : String
        "The items it contains"
        data : [SasakiObject!]!
    }

    # schema here
    type ViewCloud {
        id: ID!
        points : [CloudPoint]
    }

    type ViewContentOption{
        target : ID!
        content : ID!
        type : ViewContentType!
    }

    type ResultCloudData {
        values : [Int]!
        option : ViewContentOption!
    }

    type ResultCloud {
        id: ID!
        points : [CloudPoint]
        data : [ResultCloudData]
    }

    type Content {
        id : ID!
    }


    type CloudPoint {
        x : Float!
        y : Float!
        z : Float!
        meta : String
    }
    type SetResultsResponse {
        success : Boolean!
        message : String
        values : [ResultCloudData!]!
    }
`;

const {gql} = require("apollo-server");

module.exports = typeDefs;