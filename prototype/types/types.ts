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

export type Bounds = {
  x: Scalars['Int'];
  y: Scalars['Int'];
  z: Scalars['Int'];
};

export type Normal = {
  x: Scalars['Int'];
  y: Scalars['Int'];
  z: Scalars['Int'];
};

export type NormalPoint = {
  Normal: Normal;
  Point: Point;
};

export type Point = {
  x: Scalars['Int'];
  y: Scalars['Int'];
  z: Scalars['Int'];
};

export type Result = {
  ResultCloud: Array<ResultCloud>;
};

export type ResultCloud = {
  NormalPoint: Array<NormalPoint>;
  ResultCloudData: ResultCloudData;
};

export type ResultCloudData = {
  data?: Maybe<Scalars['String']>;
  here?: Maybe<Scalars['String']>;
  right?: Maybe<Scalars['String']>;
  some?: Maybe<Scalars['String']>;
};
