// src/components/MainContent.tsx

import React, {useEffect, useState} from 'react';
import './Container.css';
import Header from "./Header";
import BannerCarousel from "./BannerCarousel";
import BestSellers from "./BestSellers";
import fakeData from "../data/fakeItems.json";
import SmallBanners from "./SmallBanners";
import PopularProducts from "./PopularProducts";
import Footer from "./Footer";
import LoginModal from "./LoginModal";
import {BrowserRouter as Router} from "react-router-dom";
import {Product} from "../types/Product";
import {searchProducts} from "../api/api";
import {CartItem} from "../types/CartItem";  // Импортируйте стили контейнера

const MainContent: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const [searchQuery, setSearchQuery] = useState('');
    const [sortCriteria, setSortCriteria] = useState('');

    const handleSearch = (query: string) => {
        setSearchQuery(query);
    };

    const handleSort = (criteria: string) => {
        setSortCriteria(criteria);
    };

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const newProducts = await searchProducts(searchQuery, sortCriteria);
                setProducts(newProducts);
            } catch (error) {
                console.error('Error fetching products:', error);
            }
        };

        fetchProducts();
    }, [searchQuery, sortCriteria]);

    const handleVerify = (phoneNumber: string, code: string) => {
        // TODO: Verify the phone number and code with the backend
    };

    const handleProductSubmit = (product: Product) => {
        // TODO: Send the product data to the backend
    };

    const [cartItems, setCartItems] = useState<CartItem[]>([]);

    const handleAddToCart = (product: Product) => {
        setCartItems(prevItems => {
            const existingItem = prevItems.find(item => item.id === product.id);
            if (existingItem) {
                return prevItems.map(item =>
                    item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
                );
            }
            return [...prevItems, { ...product, quantity: 1 }];
        });
    };

    const handleRemoveFromCart = (productId: string) => {
        setCartItems(prevItems => prevItems.filter(item => item.id !== productId));
    };

    const handleOrder = (customerInfo: { name: string, address: string }) => {
        // TODO: Send order information to the backend
    };

    const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

    const handleLoginClick = () => {
        setIsLoginModalOpen(true);
    };

    const handleCloseLoginModal = () => {
        setIsLoginModalOpen(false);
    };

    return (
        <div className="container">  {/* Оберните содержимое в контейнер */}
            <Router>
                <div className="app">
                    <Header onLoginClick={handleLoginClick} />
                    <div className="content">
                        <BannerCarousel />  {/* Добавьте компонент BannerCarousel */}
                        <BestSellers products={fakeData.products.slice(0, 5)} />  {/* Displaying first 5 products as best sellers */}
                        <SmallBanners />
                        <PopularProducts />
                    </div>
                    <Footer />
                    <LoginModal isOpen={isLoginModalOpen} onClose={handleCloseLoginModal} />
                </div>
            </Router>
        </div>
    );
};

export default MainContent;
