import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css'
import MainPage from './pages/MainPage'
import RegisterForm from './pages/RegisterForm'
import LoginForm from './pages/LoginForm'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage/>} />
        <Route path="/register" element={<RegisterForm/>} />
        <Route path="/login" element={<LoginForm/>} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
