// src/components/AuthForm.tsx
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const AuthForm: React.FC = () => {
    const [phone, setPhone] = useState('');
    const [code, setCode] = useState('');
    const [isCodeSent, setIsCodeSent] = useState(false);

    const handlePhoneSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        // TODO: отправка номера телефона на сервер для проверки/регистрации
        setIsCodeSent(true);
    };

    const handleCodeSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        // TODO: отправка кода на сервер для верификации
    };

    return (
        <div className="container">
            {!isCodeSent ? (
                <form onSubmit={handlePhoneSubmit}>
                    <div className="mb-3">
                        <label htmlFor="phone" className="form-label">Номер телефона</label>
                        <input type="text" className="form-control" id="phone" value={phone} onChange={e => setPhone(e.target.value)} />
                    </div>
                    <button type="submit" className="btn btn-primary">Продолжить</button>
                </form>
            ) : (
                <form onSubmit={handleCodeSubmit}>
                    <div className="mb-3">
                        <label htmlFor="code" className="form-label">Код из СМС</label>
                        <input type="text" className="form-control" id="code" value={code} onChange={e => setCode(e.target.value)} />
                    </div>
                    <button type="submit" className="btn btn-primary">Войти</button>
                </form>
            )}
        </div>
    );
};

export default AuthForm;