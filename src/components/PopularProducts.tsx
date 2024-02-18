// src/components/PopularProducts.tsx

import React, { useState, useEffect } from 'react';
import ProductCard from './ProductCard';
import { Product } from '../types/Product';
import fakeData from '../data/fakeItems.json';
import './PopularProducts.css';

const PopularProducts: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const [page, setPage] = useState(1);
    const [loading, setLoading] = useState(false);

    const loadMoreProducts = async () => {
        setLoading(true);
        const newProducts: Product[] = fakeData.products.slice((page - 1) * 4, page * 4);
        setProducts((prevProducts: Product[]): Product[] => [...prevProducts, ...newProducts]);
        setPage(prevPage => prevPage + 1);
        setLoading(false);
    };


    useEffect(() => {
        window.addEventListener('scroll', handleScroll);
        return () => window.removeEventListener('scroll', handleScroll);
    }, [products]);

    const handleScroll = () => {
        if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 500 && !loading) {
            loadMoreProducts();
        }
    };

    return (
        <div className="popular-products-section">
            <h2>Популярные товары</h2>
            <div className="product-row">
                {products.map(product => (
                    <ProductCard key={product.id} product={product} />
                ))}
            </div>
            {loading && <div>Loading more products...</div>}
        </div>
    );
};

export default PopularProducts;
