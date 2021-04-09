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
        this.articleDisplay = result.data;
      })
      .catch((err) => {
        this.$toast.error(err);
      });
  },
};
</script>
