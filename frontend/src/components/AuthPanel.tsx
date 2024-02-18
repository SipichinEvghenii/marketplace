// src/components/AuthPanel.tsx
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

interface AuthPanelProps {
    onVerify: (phoneNumber: string, code: string) => void;
}

const AuthPanel: React.FC<AuthPanelProps> = ({ onVerify }) => {
    const [phoneNumber, setPhoneNumber] = useState('');
    const [verificationCode, setVerificationCode] = useState('');
    const [isCodeSent, setIsCodeSent] = useState(false);

    const handleSendCode = async (e: React.FormEvent) => {
        e.preventDefault();
        // TODO: Send verification code
        setIsCodeSent(true);
    };

    const handleVerify = (e: React.FormEvent) => {
        e.preventDefault();
        onVerify(phoneNumber, verificationCode);
    };

    return (
        <div className="auth-panel">
            {!isCodeSent ? (
                <form onSubmit={handleSendCode}>
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Enter your phone number"
                        value={phoneNumber}
                        onChange={e => setPhoneNumber(e.target.value)}
                    />
                    <button type="submit" className="btn btn-primary mt-2">Send Code</button>
                </form>
            ) : (
                <form onSubmit={handleVerify}>
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Enter verification code"
                        value={verificationCode}
                        onChange={e => setVerificationCode(e.target.value)}
                    />
                    <button type="submit" className="btn btn-primary mt-2">Verify</button>
                </form>
            )}
        </div>
    );
};

export default AuthPanel;