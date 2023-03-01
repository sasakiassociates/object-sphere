const {gql} = require("apollo-server");

const typeDefs = gql`

    """
    A set of statuses a Content type would utilize in a View Study
    """
    enum ViewContentType {
        """
        The potential content item used to gather the max amount of pixels in a view
        """
        TARGET
        """
        The main blocking content item that sets the study with a current condition value
        """
        EXISTING
        """
        Optional content items that gives studies the ability to have multiple scenarios
        """
        PROPOSED
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
    type Query {
        results : [ResultCloud]!
        result(id : ID!) : ResultCloud
        data(target : ID!, content : ID! ,type : ViewContentType!) : ResultCloudData
    }

    type SetResultsResponse {
        success : Boolean!
        message : String
        values : [ResultCloudData!]!
    }

    type Mutation{
        setResults(id : ID!) : SetResultsResponse!
        addResults(id : ID!) : SetResultsResponse!

    }
`;

module.exports = typeDefs;