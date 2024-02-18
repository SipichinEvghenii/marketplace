// src/components/ProductList.tsx
import React from 'react';
import fakeData from '../data/fakeItems.json';
import { Card, Button } from 'react-bootstrap';
import './ProductList.css';
const ProductList: React.FC = () => {
    return (
        <div className="product-list">
            {fakeData.products.map(product => (
                <Card style={{ width: '18rem' }} key={product.id} className="product-item">
                    <Card.Img variant="top" src="https://via.placeholder.com/150" alt={product.name} />
                    <Card.Body>
                        <Card.Title>{product.name}</Card.Title>
                        <Card.Text>
                            {product.description}
                        </Card.Text>
                        <Card.Text>
                            Цена: {product.price} €
                        </Card.Text>
                        <Button variant="primary">Добавить в корзину</Button>
                    </Card.Body>
                </Card>
            ))}
        </div>
    );
}

export default ProductList;
