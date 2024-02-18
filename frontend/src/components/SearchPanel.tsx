// src/components/SearchPanel.tsx
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

interface SearchPanelProps {
    onSearch: (query: string) => void;
    onSort: (criteria: string) => void;
}

const SearchPanel: React.FC<SearchPanelProps> = ({ onSearch, onSort }) => {
    const [searchQuery, setSearchQuery] = useState('');

    const handleSearch = (e: React.FormEvent) => {
        e.preventDefault();
        onSearch(searchQuery);
    };

    return (
        <div className="d-flex justify-content-between my-4">
            <form onSubmit={handleSearch} className="d-flex">
                <input
                    type="text"
                    className="form-control"
                    placeholder="Search for products..."
                    value={searchQuery}
                    onChange={e => setSearchQuery(e.target.value)}
                />
                <button type="submit" className="btn btn-primary ml-2">Search</button>
            </form>
            <div>
                <button onClick={() => onSort('price')} className="btn btn-outline-secondary mr-2">Sort by Price</button>
                <button onClick={() => onSort('popularity')} className="btn btn-outline-secondary mr-2">Sort by Popularity</button>
                <button onClick={() => onSort('date')} className="btn btn-outline-secondary">Sort by Date</button>
            </div>
        </div>
    );
};

export default SearchPanel;