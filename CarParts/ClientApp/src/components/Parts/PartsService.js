import axios from 'axios';

export default class PartsService {
    static getParts(model) {
        return axios.post('/api/parts/getparts', model);
    }

    // static getPart(id){
    //     return axios.get('/api/parts/getpart', id);
    // }

}