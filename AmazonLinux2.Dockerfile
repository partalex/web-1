FROM amazonlinux:latest

RUN yum update -y && \
#    yum install -y git docker && \
#    yum install -y docker && \
#    curl -L "https://github.com/docker/compose/releases/latest/download/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose && \
#    chmod +x /usr/local/bin/docker-compose
    
# Start with an interactive shell
CMD ["/bin/bash"]
