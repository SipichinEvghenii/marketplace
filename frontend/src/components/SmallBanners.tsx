// src/components/SmallBanners.tsx

import React from 'react';
import './SmallBanners.css';

const SmallBanners: React.FC = () => {
    return (
        <div className="small-banners-row">
            <div className="small-banner">
                <img src="https://via.placeholder.com/370" alt="Banner 1" />
            </div>
            <div className="small-banner">
                <img src="https://via.placeholder.com/370" alt="Banner 2" />
            </div>
            <div className="small-banner">
                <img src="https://via.placeholder.com/370" alt="Banner 3" />
            </div>
        </div>
    );
};

export default SmallBanners;
