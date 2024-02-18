// src/components/BestSellers.tsx

import React from 'react';
import ProductCard from './ProductCard';
import { Product } from '../types/Product';
import './BestSellers.css';

interface BestSellersProps {
    products: Product[];
}

const BestSellers: React.FC<BestSellersProps> = ({ products }) => {
    return (
        <div className="best-sellers-section">
            <h2>Хиты продаж</h2>
            <div className="product-row">
                {products.map(product => (
                    <ProductCard key={product.id} product={product} />
                ))}
            </div>
        </div>
    );
};

export default BestSellers;
