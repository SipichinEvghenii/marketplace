// src/components/LoginModal.tsx
import React, { useState } from 'react';
import { Modal, Button, Form, Alert } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

interface LoginModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const LoginModal: React.FC<LoginModalProps> = ({ isOpen, onClose }) => {
    const [isPhoneNumberEntered, setIsPhoneNumberEntered] = useState(false);
    const [verificationCode, setVerificationCode] = useState('');
    const [isCodeIncorrect, setIsCodeIncorrect] = useState(false);
    const navigate = useNavigate();

    const handlePhoneSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        setIsPhoneNumberEntered(true);
    };

    const handleCodeSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        if (verificationCode === '1234') {
            navigate('/');
            onClose();
        } else {
            setIsCodeIncorrect(true);
        }
    };

    return (
        <Modal show={isOpen} onHide={onClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>Вход в систему</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {!isPhoneNumberEntered ? (
                    <Form onSubmit={handlePhoneSubmit}>
                        <Form.Group controlId="formPhoneNumber" className="mb-3">
                            <Form.Label>Номер телефона</Form.Label>
                            <Form.Control type="text" placeholder="Введите ваш номер телефона" />
                        </Form.Group>
                        <Button variant="primary" type="submit">
                            Отправить код
                        </Button>
                    </Form>
                ) : (
                    <Form onSubmit={handleCodeSubmit}>
                        <Form.Group controlId="formVerificationCode" className="mb-3">
                            <Form.Label>Код подтверждения</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Введите код подтверждения"
                                value={verificationCode}
                                onChange={e => setVerificationCode(e.target.value)}
                            />
                        </Form.Group>
                        {isCodeIncorrect && <Alert variant="danger">Неверный код</Alert>}
                        <Button variant="primary" type="submit">
                            Войти
                        </Button>
                    </Form>
                )}
            </Modal.Body>
        </Modal>
    );
}

export default LoginModal;
