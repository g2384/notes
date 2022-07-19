# JS Methods

## Find nearest fraction number

```js
max = 10;
target = '0.3333';
decimalPlaces = target.split('.')[1].length;
for (var i = 0; i < max; i++) {
    for (var j = 0; j < max; j++) {
        if ((i / j).toFixed(decimalPlaces).toString().indexOf(target) >= 0) {
            console.log(i + '/' + j + ' = ' + i / j)
        }
    }
}
```