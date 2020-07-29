import axios from 'axios';

export default class PartsService {
    // static getParts(model) {
    //     return axios.post('/api/parts/getparts', model);
    // }

    static getParts(model) {
        return axios.get('/test-data.json', model);
    }

}