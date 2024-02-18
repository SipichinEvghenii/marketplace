import React from 'react';
import './Footer.css';

const Footer: React.FC = () => {
    return (
        <footer className="app-footer">
            <div className="footer-content">
                <section className="footer-section">
                    <h3>Покупателям</h3>
                    <ul>
                        <li><a href="/how-to-order">Как сделать заказ</a></li>
                        <li><a href="/payment-methods">Способы оплаты</a></li>
                        <li><a href="/delivery">Доставка</a></li>
                        <li><a href="/returns">Возврат товара</a></li>
                        <li><a href="/refund">Возврат денежных средств</a></li>
                        <li><a href="/sales-rules">Правила продажи</a></li>
                        <li><a href="/platform-rules">Правила пользования платформой</a></li>
                        <li><a href="/faq">Вопросы и ответы</a></li>
                    </ul>
                </section>

                <section className="footer-section">
                    <h3>Партнерам</h3>
                    <ul>
                        <li><a href="/sell-with-us">Продавайте у нас</a></li>
                        <li><a href="/courier-partners">Курьерам</a></li>
                        <li><a href="/carriers">Перевозчикам</a></li>
                        <li><a href="/pickup-points">Партнерские пункты выдачи</a></li>
                    </ul>
                </section>

                <section className="footer-section">
                    <h3>Наши проекты</h3>
                    <ul>
                        <li><a href="/job-opportunities">Трудоустройство</a></li>
                        <li><a href="/digital-products">Цифровые товары</a></li>
                        <li><a href="/wb-travels">TCL Путешествия</a></li>
                        <li><a href="/wb-stream">TCL Stream</a></li>
                    </ul>
                </section>

                <section className="footer-section">
                    <h3>TCL Studio</h3>
                    <ul>
                        <li><a href="/about-us">О нас</a></li>
                        <li><a href="/contact-details">Контактные данные</a></li>
                        <li><a href="/press-center">Пресс-центр</a></li>
                    </ul>
                </section>

                <section className="footer-section social-links">
                    <h3>Мы в соцсетях</h3>
                    <ul>
                        <li><a href="https://www.instagram.com/">Instagram</a></li>
                        <li><a href="https://youtube.com">YouTube</a></li>
                        <li><a href="https://telegram.org">Telegram</a></li>
                    </ul>
                </section>
            </div>

            <div className="footer-bottom">
                <p>2023 © Marketplace — платформа для всех ваших покупок. От ежедневных товаров до уникальных находок.</p>
                <p>Все права защищены. Доставка по всей Молдове.</p>
            </div>
        </footer>
    );
}

export default Footer;
