import React, { useState } from 'react';
import { paymentService } from './services/paymentService';

function App() {
  const [operation, setOperation] = useState('');
  const [result, setResult] = useState(null);
  const [error, setError] = useState(null);
  const [formData, setFormData] = useState({
    serviceType: '',
    previousReading: '',
    currentReading: '',
    rate: '',
    paymentMethod: '',
    amount: '',
    currency: 'MDL',
    hasSufficientFunds: false
  });

  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setResult(null);

    try {
      let response;
      switch (operation) {
        case 'generateInvoice':
          response = await paymentService.generateInvoice({
            serviceType: formData.serviceType,
            previousReading: parseFloat(formData.previousReading),
            currentReading: parseFloat(formData.currentReading),
            rate: parseFloat(formData.rate)
          });
          break;
        case 'generateInvoiceAndPayment':
          response = await paymentService.generateInvoiceAndPayment({
            serviceType: formData.serviceType,
            previousReading: parseFloat(formData.previousReading),
            currentReading: parseFloat(formData.currentReading),
            rate: parseFloat(formData.rate),
            paymentMethod: formData.paymentMethod
          });
          break;
        case 'processPayment':
          response = await paymentService.processPayment({
            paymentMethod: formData.paymentMethod,
            amount: parseFloat(formData.amount),
            currency: formData.currency
          });
          break;
        case 'quickPayment':
          response = await paymentService.quickPayment({
            serviceType: formData.serviceType,
            paymentMethod: formData.paymentMethod
          });
          break;
        case 'paymentWithLogging':
          response = await paymentService.paymentWithLogging({
            paymentMethod: formData.paymentMethod,
            amount: parseFloat(formData.amount),
            currency: formData.currency
          });
          break;
        case 'calculateTax':
          response = await paymentService.calculateTax({
            serviceType: formData.serviceType,
            amount: parseFloat(formData.amount)
          });
          break;
        case 'validatePaymentChain':
          response = await paymentService.validatePaymentChain({
            amount: parseFloat(formData.amount),
            hasSufficientFunds: formData.hasSufficientFunds
          });
          break;
        case 'validatePaymentCommand':
          response = await paymentService.validatePaymentCommand({
            amount: parseFloat(formData.amount),
            hasSufficientFunds: formData.hasSufficientFunds
          });
          break;
        default:
          throw new Error('Operațiune invalidă');
      }
      setResult(response);
    } catch (err) {
      setError(err.message);
    }
  };

  const renderForm = () => {
    switch (operation) {
      case 'generateInvoice':
        return (
          <>
            <div>
              <label>Tip Serviciu:</label>
              <select name="serviceType" value={formData.serviceType} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="ELECTRICITY">Electricitate</option>
                <option value="WATER">Apă</option>
              </select>
            </div>
            <div>
              <label>Citire Anterioară:</label>
              <input type="number" name="previousReading" value={formData.previousReading} onChange={handleInputChange} />
            </div>
            <div>
              <label>Citire Curentă:</label>
              <input type="number" name="currentReading" value={formData.currentReading} onChange={handleInputChange} />
            </div>
            <div>
              <label>Rată:</label>
              <input type="number" name="rate" value={formData.rate} onChange={handleInputChange} />
            </div>
          </>
        );
      case 'generateInvoiceAndPayment':
        return (
          <>
            <div>
              <label>Tip Serviciu:</label>
              <select name="serviceType" value={formData.serviceType} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="ELECTRICITY">Electricitate</option>
                <option value="WATER">Apă</option>
              </select>
            </div>
            <div>
              <label>Citire Anterioară:</label>
              <input type="number" name="previousReading" value={formData.previousReading} onChange={handleInputChange} />
            </div>
            <div>
              <label>Citire Curentă:</label>
              <input type="number" name="currentReading" value={formData.currentReading} onChange={handleInputChange} />
            </div>
            <div>
              <label>Rată:</label>
              <input type="number" name="rate" value={formData.rate} onChange={handleInputChange} />
            </div>
            <div>
              <label>Metodă Plată:</label>
              <select name="paymentMethod" value={formData.paymentMethod} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="MPAY">MPay</option>
                <option value="MAIB">MAIB</option>
              </select>
            </div>
          </>
        );
      case 'processPayment':
        return (
          <>
            <div>
              <label>Metodă Plată:</label>
              <select name="paymentMethod" value={formData.paymentMethod} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="MPAY">MPay</option>
                <option value="MAIB">MAIB</option>
              </select>
            </div>
            <div>
              <label>Sumă:</label>
              <input type="number" name="amount" value={formData.amount} onChange={handleInputChange} />
            </div>
            <div>
              <label>Monedă:</label>
              <select name="currency" value={formData.currency} onChange={handleInputChange}>
                <option value="MDL">MDL</option>
                <option value="EUR">EUR</option>
                <option value="USD">USD</option>
              </select>
            </div>
          </>
        );
      case 'quickPayment':
        return (
          <>
            <div>
              <label>Tip Serviciu:</label>
              <select name="serviceType" value={formData.serviceType} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="ELECTRICITY">Electricitate</option>
                <option value="WATER">Apă</option>
              </select>
            </div>
            <div>
              <label>Metodă Plată:</label>
              <select name="paymentMethod" value={formData.paymentMethod} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="MPAY">MPay</option>
                <option value="MAIB">MAIB</option>
              </select>
            </div>
          </>
        );
      case 'paymentWithLogging':
        return (
          <>
            <div>
              <label>Metodă Plată:</label>
              <select name="paymentMethod" value={formData.paymentMethod} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="MPAY">MPay</option>
                <option value="MAIB">MAIB</option>
              </select>
            </div>
            <div>
              <label>Sumă:</label>
              <input type="number" name="amount" value={formData.amount} onChange={handleInputChange} />
            </div>
            <div>
              <label>Monedă:</label>
              <select name="currency" value={formData.currency} onChange={handleInputChange}>
                <option value="MDL">MDL</option>
                <option value="EUR">EUR</option>
                <option value="USD">USD</option>
              </select>
            </div>
          </>
        );
      case 'calculateTax':
        return (
          <>
            <div>
              <label>Tip Serviciu:</label>
              <select name="serviceType" value={formData.serviceType} onChange={handleInputChange}>
                <option value="">Selectează...</option>
                <option value="ELECTRICITY">Electricitate</option>
                <option value="WATER">Apă</option>
              </select>
            </div>
            <div>
              <label>Sumă:</label>
              <input type="number" name="amount" value={formData.amount} onChange={handleInputChange} />
            </div>
          </>
        );
      case 'validatePaymentChain':
      case 'validatePaymentCommand':
        return (
          <>
            <div>
              <label>Sumă:</label>
              <input type="number" name="amount" value={formData.amount} onChange={handleInputChange} />
            </div>
            <div>
              <label>
                <input
                  type="checkbox"
                  name="hasSufficientFunds"
                  checked={formData.hasSufficientFunds}
                  onChange={handleInputChange}
                />
                Fonduri Suficiente
              </label>
            </div>
          </>
        );
      default:
        return null;
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Sistem de Facturare și Plăți</h1>
      
      <div className="mb-4">
        <label className="block mb-2">Selectează Operațiunea:</label>
        <select
          value={operation}
          onChange={(e) => setOperation(e.target.value)}
          className="w-full p-2 border rounded"
        >
          <option value="">Selectează...</option>
          <option value="generateInvoice">Generare Factură</option>
          <option value="generateInvoiceAndPayment">Generare Factură și Plată</option>
          <option value="processPayment">Procesare Plată</option>
          <option value="quickPayment">Plată Rapidă</option>
          <option value="paymentWithLogging">Plată cu Logare</option>
          <option value="calculateTax">Calcul Taxe</option>
          <option value="validatePaymentChain">Validare Plată (Chain)</option>
          <option value="validatePaymentCommand">Validare Plată (Command)</option>
        </select>
      </div>

      {operation && (
        <form onSubmit={handleSubmit} className="space-y-4">
          {renderForm()}
          <button
            type="submit"
            className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
          >
            Execută
          </button>
        </form>
      )}

      {error && (
        <div className="mt-4 p-4 bg-red-100 text-red-700 rounded">
          {error}
        </div>
      )}

      {result && (
        <div className="mt-4 p-4 bg-green-100 text-green-700 rounded">
          <pre>{JSON.stringify(result, null, 2)}</pre>
        </div>
      )}
    </div>
  );
}

export default App; 