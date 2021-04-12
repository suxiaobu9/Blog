<template>
  <div>
    <article>
      <h1>{{ articleDisplay.title }}</h1>
      <span class="tag">{{ articleDisplay.createTime }}</span>
      <hr />
      <markdown-it-vue class="md-body" :content="articleDisplay.mdContent" />
    </article>
  </div>
</template>

<script>
import $ from "jquery";
export default {
  name: "ArticleDisplay",
  data() {
    return {
      articleDisplay: {
        title: "",
        createTime: "",
        mdContent: "",
      },
    };
  },
  mounted() {
    this.$http
      .get(
        `${process.env.VUE_APP_BASEAPIURL}/blog/getarticle?id=${this.$route.params.id}`
      )
      .then((result) => {
        let mdContent = result.data.mdContent.split("\r\n");
        result.data.mdContent = "";
        const regex = /\S*!\[\w+\]\(\S+\)/;
        $.each(mdContent, function (index, item) {
          if (!regex.test(item)) {
            result.data.mdContent += `${item} \r\n `;
            return true;
          }
          var start = item.indexOf("(") + 1;
          var end = item.indexOf(")");
          var url = item.substring(start, end);

          item = item.replace(url, `${process.env.VUE_APP_BASEAPIURL}${url}`);
          result.data.mdContent += `${item} \r\n `;
        });
        this.articleDisplay = result.data;
      })
      .catch((err) => {
        this.$toast.error(err);
      });
  },
};
</script>
