import React from 'react';
import { Link } from 'react-router-dom';
import './Header.css';

interface HeaderProps {
    onLoginClick: () => void;
}

const Header: React.FC<HeaderProps> = ({ onLoginClick }) => {
    return (
        <header className="app-header">
            <div className="header-top">
                <div className="language-select">
                    <select>
                        <option value="en">EN</option>
                        <option value="ro">RO</option>
                        <option value="ru">RU</option>
                    </select>
                </div>
                <div className="header-links">
                    <a href="/support">Поддержка</a>
                    <a href="/delivery">Доставка</a>
                    <a href="/warranty">Гарантия</a>
                </div>
            </div>

            <div className="header-center">
                <div className="logo">
                    <a href="/">Логотип</a>
                </div>
                <div className="search">
                    <input type="text" placeholder="Поиск товаров" />
                    <button>Поиск</button>
                </div>
                <div className="user">
                    <Link to="/notifications">Уведомления</Link>
                    <Link to="#" onClick={onLoginClick}>Войти</Link>
                    <Link to="/orders">Заказы</Link>
                    <Link to="/bag">Корзина</Link>
                </div>
            </div>

            <div className="header-bottom">
                <div className="all-categories">
                    <button>☰ Все категории</button>
                </div>
                <div className="main-categories">
                    <a href="/category1">Дома</a>
                    <a href="/category2">Красота</a>
                    <a href="/category3">Аксессуары</a>
                    <a href="/category4">Электроника</a>
                    <a href="/category5">Игрушки</a>
                    <a href="/category6">Мебель</a>
                    <a href="/category7">Продукты</a>
                    <a href="/category8">Электроника</a>
                    <a href="/category9">Спорт</a>
                    <a href="/category10">Канцтовары</a>
                </div>
            </div>
        </header>
    );
}

export default Header;
