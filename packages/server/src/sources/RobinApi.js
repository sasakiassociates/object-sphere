import { RESTDataSource } from '@apollo/datasource-rest';

 export default class RobinApi extends RESTDataSource {
  
  constructor(options){
    super(options);
    this.token = options.token;
    this.baseURL = 'https://api.robinpowered.com/v1.0/';
  }

  willSendRequest(_path, request){
    request.headers['Authorization'] = 'Access-Token ' + this.token;
    request.headers['accept'] ='application/json';
  }

  async getAuth(){
    return this.get(`auth`);
  }

  async getSpaces(id){
    return this.get(`locations/${encodeURIComponent(id)}/spaces`);
  }
  async getSpace(id) {
    return this.get(`spaces/${encodeURIComponent(id)}`);
  }

  async getLocation(id) {
    const res =  this.get(`locations/${encodeURIComponent(id)}`);
    return res['data'];
  }

  async getOrganization(id) {
    return this.get(`organizations/${encodeURIComponent(id)}`);
  }
}