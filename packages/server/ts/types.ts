export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
export type MakeEmpty<T extends { [key: string]: unknown }, K extends keyof T> = { [_ in K]?: never };
export type Incremental<T> = T | { [P in keyof T]?: P extends ' $fragmentName' | '__typename' ? T[P] : never };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: { input: string; output: string; }
  String: { input: string; output: string; }
  Boolean: { input: boolean; output: boolean; }
  Int: { input: number; output: number; }
  Float: { input: number; output: number; }
};

export type Building = {
  __typename?: 'Building';
  id: Scalars['ID']['output'];
  name?: Maybe<Scalars['String']['output']>;
};

export type CloudPoint = {
  __typename?: 'CloudPoint';
  meta: Scalars['String']['output'];
  x: Scalars['Int']['output'];
  y: Scalars['Int']['output'];
  z: Scalars['Int']['output'];
};

export type ContextOption = {
  __typename?: 'ContextOption';
  content?: Maybe<ViewContext>;
  target?: Maybe<ViewContext>;
};

export type Desk = RobinObject & {
  __typename?: 'Desk';
  id: Scalars['Int']['output'];
  name: Scalars['String']['output'];
};

export type Location = RobinObject & {
  __typename?: 'Location';
  account_id: Scalars['Int']['output'];
  address?: Maybe<Scalars['String']['output']>;
  id: Scalars['Int']['output'];
  latitude?: Maybe<Scalars['Float']['output']>;
  longitude?: Maybe<Scalars['Float']['output']>;
  name?: Maybe<Scalars['String']['output']>;
};

export type Organization = RobinObject & {
  __typename?: 'Organization';
  id: Scalars['Int']['output'];
  name?: Maybe<Scalars['String']['output']>;
};

export type Query = {
  __typename?: 'Query';
  auth?: Maybe<Scalars['Boolean']['output']>;
  building?: Maybe<Building>;
  location?: Maybe<Location>;
  organization?: Maybe<Organization>;
  space?: Maybe<Space>;
  spaces?: Maybe<Array<Maybe<Space>>>;
};


export type QueryBuildingArgs = {
  id: Scalars['ID']['input'];
};


export type QueryLocationArgs = {
  id: Scalars['Int']['input'];
};


export type QueryOrganizationArgs = {
  id: Scalars['Int']['input'];
};


export type QuerySpaceArgs = {
  id: Scalars['Int']['input'];
};


export type QuerySpacesArgs = {
  id: Scalars['Int']['input'];
};

export type ResulData = {
  __typename?: 'ResulData';
  id?: Maybe<Scalars['String']['output']>;
  info: ContextOption;
  values: Array<Scalars['Float']['output']>;
};

export type ResultCloud = {
  __typename?: 'ResultCloud';
  Point: Array<CloudPoint>;
  ResultCloudData: ResulData;
};

export type RobinObject = {
  id: Scalars['Int']['output'];
  name?: Maybe<Scalars['String']['output']>;
};

export type Space = RobinObject & {
  __typename?: 'Space';
  description?: Maybe<Scalars['String']['output']>;
  id: Scalars['Int']['output'];
  level_id?: Maybe<Scalars['Int']['output']>;
  name?: Maybe<Scalars['String']['output']>;
  type?: Maybe<Scalars['String']['output']>;
};

export type ViewContext = {
  __typename?: 'ViewContext';
  contentType?: Maybe<Scalars['String']['output']>;
  id?: Maybe<Scalars['String']['output']>;
  name: Scalars['String']['output'];
};
