import axios from 'axios';

export default class SelectService {
    static getYears() {
        return axios.get('/api/mainpage/getyears');
    }

    static getMarks(year) {
        return axios.post('/api/mainpage/getmark', year);
    }

    
    static getModel(markid) {
        return axios.post('/api/mainpage/getmodel', markid);
    }
}