import axios from 'axios';

export default class CategoryService {
    static getCategories() {
        return axios.get('/api/mainpage/getcategory');
    }
}