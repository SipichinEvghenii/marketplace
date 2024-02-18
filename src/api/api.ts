// src/api/api.ts
import axios from 'axios';

const api = axios.create({
    baseURL: 'https://your-backend-url.com/api',
});

export const searchProducts = async (query: string, sort: string) => {
    try {
        const response = await api.get('/products', {
            params: { query, sort },
        });
        return response.data;
    } catch (error) {
        console.error('Error fetching products:', error);
        throw error;
    }
};