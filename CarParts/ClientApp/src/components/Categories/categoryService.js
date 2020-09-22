import axios from 'axios';

export default class CategoryService {
    static getCategories(model) {
        return axios.get('/api/categories/getcategory', model);
    }
}