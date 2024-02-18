// src/components/ProductForm.tsx
import React, { useState } from 'react';
import { Product } from '../types/Product';
import 'bootstrap/dist/css/bootstrap.min.css';

interface ProductFormProps {
    product?: Product;
    onSubmit: (product: Product) => void;
}

const ProductForm: React.FC<ProductFormProps> = ({ product, onSubmit }) => {
    const [name, setName] = useState(product ? product.name : '');
    const [description, setDescription] = useState(product ? product.description : '');
    const [price, setPrice] = useState(product ? product.price.toString() : '');
    const [image, setImage] = useState(product ? product.image : '');

    const handleFormSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        const newProduct: Product = {
            rating: 0,
            id: product ? product.id : new Date().getTime().toString(),
            name,
            description,
            price: parseFloat(price),
            image
        };
        onSubmit(newProduct);
    };

    return (
        <form onSubmit={handleFormSubmit}>
            <div className="mb-3">
                <label className="form-label">Product Name</label>
                <input
                    type="text"
                    className="form-control"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Description</label>
                <textarea
                    className="form-control"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                ></textarea>
            </div>
            <div className="mb-3">
                <label className="form-label">Price</label>
                <input
                    type="number"
                    className="form-control"
                    value={price}
                    onChange={(e) => setPrice(e.target.value)}
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Image URL</label>
                <input
                    type="text"
                    className="form-control"
                    value={image}
                    onChange={(e) => setImage(e.target.value)}
                />
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
        </form>
    );
};

export default ProductForm;