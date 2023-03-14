export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
};

export type Box = {
  __typename?: 'Box';
  center?: Maybe<CloudPoint>;
  xsize?: Maybe<Scalars['Float']>;
  ysize?: Maybe<Scalars['Float']>;
  zsize?: Maybe<Scalars['Float']>;
};

export type CloudPoint = {
  __typename?: 'CloudPoint';
  meta?: Maybe<Scalars['String']>;
  point: Vector;
};

export type Normal = {
  x: Scalars['Float'];
  y: Scalars['Float'];
  z: Scalars['Float'];
};

export type NormalCloud = SasakiObject & {
  __typename?: 'NormalCloud';
  id: Scalars['ID'];
  name?: Maybe<Scalars['String']>;
  normals?: Maybe<Array<Maybe<NormalPoint>>>;
};

export type NormalPoint = {
  __typename?: 'NormalPoint';
  meta?: Maybe<Scalars['String']>;
  normal: Normal;
  point: Point;
};

export type Point = {
  x: Scalars['Float'];
  y: Scalars['Float'];
  z: Scalars['Float'];
};

export type Query = {
  __typename?: 'Query';
  getObject?: Maybe<SasakiObject>;
  getPoints?: Maybe<Array<Maybe<CloudPoint>>>;
};


export type QueryGetObjectArgs = {
  id: Scalars['ID'];
};


export type QueryGetPointsArgs = {
  box?: InputMaybe<Box>;
};

/** A simple container object that is mainly used for acting as an anchor point for a specific workflow type */
export type SasakiContainer = {
  /** The id related to the reference object id */
  id: Scalars['ID'];
  /** An optional name for the object */
  name?: Maybe<Scalars['String']>;
  /** The items it contains */
  objects: Array<SasakiObject>;
};

/** A simple object used for Sasaki projects */
export type SasakiObject = {
  /** The id related to the reference object id */
  id: Scalars['ID'];
  /** An optional name for the object */
  name?: Maybe<Scalars['String']>;
};

export type Vector = {
  x: Scalars['Float'];
  y: Scalars['Float'];
  z: Scalars['Float'];
};

export type ViewCloud = SasakiObject & {
  __typename?: 'ViewCloud';
  id: Scalars['ID'];
  name?: Maybe<Scalars['String']>;
  points?: Maybe<Array<Maybe<CloudPoint>>>;
};

/** A set of statuses a Content type would utilize in a View Study */
export enum ViewContentType {
  /** The main blocking content item that sets the study with a current condition value */
  Existing = 'EXISTING',
  /** Optional content items that gives studies the ability to have multiple scenarios */
  Proposed = 'PROPOSED',
  /** The potential content item used to gather the max amount of pixels in a view */
  Target = 'TARGET'
}
