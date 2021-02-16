## 1.[att=value] 匹配包含給定屬性的元素

```js
$("[name=checkbox3]").click();
```

[ ] checkbox1
<input type=checkbox> checkbox1<br>
<input type=checkbox> checkbox2<br>
<input type=checkbox checked> checkbox3<br>
<input type=checkbox> checkbox4<br>
<input type=checkbox> checkbox1test<br>
<input type=checkbox> checkbox2test<br>
<input type=checkbox> checkbox3test<br>
<input type=checkbox> checkbox4test<br>

## 2.[att*=value] 模糊匹配

```js
$("[name*=x1]").click();
```

<input type=checkbox checked> checkbox1<br>
<input type=checkbox> checkbox2<br>
<input type=checkbox> checkbox3<br>
<input type=checkbox> checkbox4<br>
<input type=checkbox checked> checkbox1test<br>
<input type=checkbox> checkbox2test<br>
<input type=checkbox> checkbox3test<br>
<input type=checkbox> checkbox4test<br>

## 3.[att!=value] 不能是這個值

```js
$("[name!=checkbox3]").click();
```

<input type=checkbox checked> checkbox1<br>
<input type=checkbox checked> checkbox2<br>
<input type=checkbox> checkbox3<br>
<input type=checkbox checked> checkbox4<br>
<input type=checkbox checked> checkbox1test<br>
<input type=checkbox checked> checkbox2test<br>
<input type=checkbox checked> checkbox3test<br>
<input type=checkbox checked> checkbox4test<br>

## 4.[att$=value] 結尾是這個值

```js
$("[name$=test]").click();
```

<input type=checkbox> checkbox1<br>
<input type=checkbox> checkbox2<br>
<input type=checkbox> checkbox3<br>
<input type=checkbox> checkbox4<br>
<input type=checkbox checked> checkbox1test<br>
<input type=checkbox checked> checkbox2test<br>
<input type=checkbox checked> checkbox3test<br>
<input type=checkbox checked> checkbox4test<br>

## 5.[att^=value] 開頭是這個值

```js
$("[name^=checkbox]").click();
```

<input type=checkbox checked> checkbox1<br>
<input type=checkbox checked> checkbox2<br>
<input type=checkbox checked> checkbox3<br>
<input type=checkbox checked> checkbox4<br>
<input type=checkbox checked> checkbox1test<br>
<input type=checkbox checked> checkbox2test<br>
<input type=checkbox checked> checkbox3test<br>
<input type=checkbox checked> checkbox4test<br>
