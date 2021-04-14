import React from 'react';
import './assets/scss/app.scss';
import Home from './pages/home/home';
import About from './pages/about/about';
import Shop from './pages/shop/shop';
import { BrowserRouter as Router, Route, Switch  } from 'react-router-dom';

function App() {
  return (
    <div className='App'>
      <Router>
        <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/about" component={About} />
            <Route exact path="/shop" component={Shop} />
        </Switch>
    </Router>
    </div>
  );
}

export default App;
