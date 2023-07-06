<script>
import { ref } from "vue";
import axios from "axios";
import backgroundImage1 from "./photos/猫互动.jpg";
import backgroundImage2 from "./photos/狗互动.jpg";
import backgroundImage3 from "./photos/主人怀抱小狗.jpg";

//网页比例大致为1920*900
// import backgroundImage3 from '@/assets/image3.jpg';
// 导入更多图片...

const backgroundImages = [backgroundImage1, backgroundImage2, backgroundImage3]; //需要更多随机图片就再加

const selectedBackgroundImage = ref(
  backgroundImages[Math.floor(Math.random() * backgroundImages.length)]
);
export default {
  data() {
    return {
      username: this.username,
      password: this.password,
    };
  },
  methods: {
    submitForm(event) {
      event.preventDefault();
      const data = {
        username: this.username,
        password: this.password,
      };
      // alert(`Hello ${this.username}!`);
      // 发送请求、处理响应等操作
      axios
        .post("/api/login", data)
        .then((response) => {
          // 处理响应
          console.log(response);

          alert("Hello ${this.username}!，登录成功！");
        })
        .catch((error) => {
          alert("登录失败！");
          console.error("请求出错:", error);
        });
    },
  },
};
</script>

<template>
  <div
    class="background-container"
    :style="{ backgroundImage: `url(${selectedBackgroundImage})` }"
  >
    <div class="logo-container">
      <img src="./photos/logo.ico" alt="Logo" class="logo" />
      <span class="logo-text">同济宠物救助中心</span>
    </div>
    <!-- 其他登录内容，比如登录表单等 -->
    <div class="form-container">
      <!-- 登录表单 -->
      <form>
        <h1>Welcome!</h1>
        <div class="form-group">
          <label for="username">账号</label>
          <input
            type="text"
            v-model="username"
            name="username"
            placeholder="请输入账号"
          />
        </div>

        <div class="form-group">
          <label for="password">密码</label>
          <input
            type="password"
            v-model="password"
            name="password"
            placeholder="请输入密码"
          />
        </div>

        <div class="form-group">
          <label class="checkbox-label" for="remember">
            <input type="checkbox" id="remember" name="remember" />
            记住密码
          </label>
        </div>

        <button type="submit" @click="submitForm">登录</button>
      </form>

      <div class="register-link">没有账号？<a href="#">这里注册</a></div>
    </div>
    <div class="info-container">
      <span class="info-text">数据库课程设计项目-宠物救助站信息管理系统</span>
    </div>
  </div>
</template>

<style scoped>
html,
body {
  height: 100%; /* 设置网页高度为100% */
  margin: 0; /* 清除默认的页面边距 */
  overflow: hidden; /* 禁止页面滚动 */
}

.form-container h1 {
  text-align: center;
  color: #fff;
}

.background-container {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  background-image: url({{ selectedBackgroundImage }});
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.logo-container {
  position: absolute;
  top: 6%; /* 调整Logo的垂直位置 */
  left: 3%; /* 调整Logo的水平位置 */
  display: flex;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2); /* 添加黑色阴影底板 */
  background-color: #7a7a7a;
  padding: 8px 12px; /* 调整底板内边距 */
  border-radius: 4px;
}

.logo {
  width: 50px; /* 调整Logo图片的宽度 */
  height: 50px; /* 调整Logo图片的高度 */
  margin-right: 10px; /* 调整Logo和文字之间的间距 */
}

.logo-text {
  color: #fff; /* 设置文字颜色为白色 */
  font-size: 32px; /* 调整文字大小 */
  font-weight: ; /* 设置文字为粗体 */
  font-family: "KaiTi", "楷体"; /*设置字体为楷体*/
}

.form-group {
  margin-bottom: 20px; /* 设置表单项目之间的垂直间距 */
  margin-left: 10%;
}

.form-container {
  position: absolute;
  width: 30%;
  height: 60%;
  top: 20%;
  right: 5%;
  display: flex;
  /* align-items: center; */
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2); /* 添加黑色阴影底板 */
  background-color: #7a7a7a;
  background-color: rgba(122, 122, 122, 0.5); /* 设置底板为半透明的 #7A7A7A */
  padding: 8px 12px; /* 调整底板内边距 */
  flex-direction: column;
}

.register-link {
  color: #fff; /* 设置链接的文字颜色 */
  text-decoration: none; /* 移除链接的下划线 */
  margin-left: 10%;
  margin-top: 20px;
}

.register-link a {
  color: #007bff; /* 设置链接的文字颜色 */
}

.info-container {
  position: absolute;
  bottom: 6%; /* 调整Logo的垂直位置 */
  left: 3%; /* 调整Logo的水平位置 */
  display: flex;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2); /* 添加黑色阴影底板 */
  background-color: rgba(122, 122, 122, 0.5); /* 设置底板为半透明的 #7A7A7A */
  /* background-color: transparent; */
  padding: 8px 12px; /* 调整底板内边距 */
  border-radius: 4px;
}

.info-text {
  font-size: 2px; /* 调整文字大小 */
  color: #000000;
  font-family: "Segoe UI", "Helvetica", sans-serif;
}

label {
  display: block; /* 让标签元素独占一行 */
  margin-bottom: 5px; /* 调整标签和输入框之间的垂直间距 */
  color: #fff;
}

input[type="text"],
input[type="password"] {
  width: 80%; /* 设置输入框宽度为100% */
  padding: 10px; /* 调整输入框的内边距 */
  border: 1px solid #ccc; /* 设置输入框的边框样式 */
  border-radius: 4px; /* 设置输入框的圆角 */
}

.checkbox-label {
  display: flex;
  align-items: center;
}

button[type="submit"] {
  width: 77%;
  padding: 10px 20px; /* 调整按钮的内边距 */
  background-color: #007bff; /* 设置按钮的背景颜色 */
  color: #fff; /* 设置按钮的文字颜色 */
  border: none; /* 移除按钮的边框 */
  border-radius: 4px; /* 设置按钮的圆角 */
  cursor: pointer; /* 设置按钮的鼠标样式为手型 */
  margin-left: 10%;
}

.register-link a:hover {
  text-decoration: underline; /* 鼠标悬停时添加下划线效果 */
}
</style>
