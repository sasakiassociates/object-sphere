const typeDefs = gql`

    "A set of statuses a Content type would utilize in a View Study"
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
        objects : [SasakiObject!]!
    }


    type ViewCloud implements SasakiObject {
        id: ID!
        name : String
        points : [CloudPoint]
    }


    type NormalCloud implements SasakiObject {
        id: ID!
        name : String
        normals : [NormalPoint]
    }

    type CloudPoint  {
        point : Vector!
        meta : String
    }

    type NormalPoint {
        point : Point!
        normal : Normal!
        meta : String
    }

    interface Point implements Vector{
        x : Float!
        y : Float!
        z : Float!
    }

    interface Normal implements Vector{
        x : Float!
        y : Float!
        z : Float!
    }

    interface Vector{
        x : Float!
        y : Float!
        z : Float!
    }

`;

const {gql} = require("apollo-server");

module.exports = typeDefs;``