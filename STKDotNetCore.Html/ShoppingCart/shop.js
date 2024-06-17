let itemList = document.querySelector('.items');
let cart = document.querySelector('.cart');
let cartList = document.querySelector('.cart-list');
let total = document.querySelector('.total');
let subtotal = document.querySelector('.subtotal');

let items = [
  {
    id: 1,
    name: 'Mouse',
    image: 'https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?q=80&w=1734&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    price: 50
  },
  {
    id: 2,
    name: 'Keyboard',
    image: 'https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8a2V5Ym9hcmR8ZW58MHx8MHx8fDA%3D',
    price: 150
  },
  {
    id: 3,
    name: 'Monitor',
    image: 'https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bW9uaXRvcnxlbnwwfHwwfHx8MA%3D%3D',
    price: 300
  },
  {
    id: 4,
    name: 'Mouse Pad',
    image: 'https://images.unsplash.com/photo-1631098983935-5363b8e50edb?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    price: 20
  },
  {
    id: 5,
    name: 'Printer',
    image: 'https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    price: 200
  },
  {
    id: 6,
    name: 'Laptop',
    image: 'https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bGFwdG9wfGVufDB8fDB8fHww',
    price: 1000
  }
]

function initItem() {
  items.forEach((value, key) => {
    let card = document.createElement('div');
    card.classList.add('card', 'col-12', 'col-sm-6', 'col-md-4', 'col-lg-3');
    card.innerHTML = `
            <img src="${value.image}" class="card-img-top" alt="...">
            <div class="card-body">
                <h4 class="card-title text-center">${value.name}</h4>
                <p class="card-text text-center">Price: ${value.price}</p>
                <button class="add-to-cart btn btn-dark form-control" onclick="addToCart(${key})">Add to Cart</button>
            </div>`;
    itemList.appendChild(card);
  });
}

initItem();

let cartLists = [];

function addToCart(key) {
  if (cartLists[key] == null) {
    cartLists[key] = JSON.parse(JSON.stringify(items[key]));
    cartLists[key].quantity = 1;
  }
  reloadCart();
}

function reloadCart() {
  cartList.innerHTML = '';
  let totalPrice = 0;
  cartLists.forEach((value, key) => {
    totalPrice = totalPrice + value.price;

    if (value != null) {
      let listItem = document.createElement('li');
      listItem.setAttribute('class', 'list-group-item');
      listItem.innerHTML = `
                <div><img src="${value.image}" style="width: 80px"/></div>
                <div><h5 class="mt-1">${value.name}</h5></div>
                <div><h6 class="mt-2">${value.price.toLocaleString()}</h6></div>
                <div>
                    <button onclick="changeQuantity(${key}, ${value.quantity - 1})">-</button>
                    <div class="count m-2">${value.quantity}</div>
                    <button onclick="changeQuantity(${key}, ${value.quantity + 1})">+</button>
                </div>`;
      cartList.appendChild(listItem);
    }
  });

  // Calculate subtotal, tax, and total
  // subtotal.innerText = totalPrice.toLocaleString();
  // tax.innerText = (totalPrice * 0.12).toLocaleString(); // Assuming 12% tax
  // total.innerText = (totalPrice + parseFloat(tax.innerText)).toLocaleString();

  subtotal.innerText = totalPrice.toLocaleString();
  total.innerText = (totalPrice).toLocaleString();
}

function changeQuantity(key, quantity) {
  if (quantity == 0) {
    delete cartLists[key];
  } else {
    cartLists[key].quantity = quantity;
    cartLists[key].price = quantity * items[key].price;
  }
  reloadCart();
}

function clearCart() {
  cartLists = [];
  reloadCart();
}
