import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css'
import MainPage from './pages/MainPage'
import RegisterForm from './pages/RegisterForm'
import LoginForm from './pages/LoginForm'
import CreateContact from './pages/CreateContact'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage/>} />
        <Route path="/register" element={<RegisterForm/>} />
        <Route path="/login" element={<LoginForm/>} />
        <Route path="/add" element={<CreateContact />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
