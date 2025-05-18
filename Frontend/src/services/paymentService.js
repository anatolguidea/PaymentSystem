const API_URL = 'http://localhost:5000/api/payment';

export const paymentService = {
    async generateInvoice(data) {
        const response = await fetch(`${API_URL}/generate-invoice`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async generateInvoiceAndPayment(data) {
        const response = await fetch(`${API_URL}/generate-invoice-and-payment`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async processPayment(data) {
        const response = await fetch(`${API_URL}/process-payment`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async quickPayment(data) {
        const response = await fetch(`${API_URL}/quick-payment`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async paymentWithLogging(data) {
        const response = await fetch(`${API_URL}/payment-with-logging`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async calculateTax(data) {
        const response = await fetch(`${API_URL}/calculate-tax`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async validatePaymentChain(data) {
        const response = await fetch(`${API_URL}/validate-payment-chain`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },

    async validatePaymentCommand(data) {
        const response = await fetch(`${API_URL}/validate-payment-command`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return response.json();
    },
}; 