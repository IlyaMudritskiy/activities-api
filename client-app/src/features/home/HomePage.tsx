import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";

export default function HomePage() {
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as="h1" inverted>
                    <Image size='massive' src='/assets/logo.png' alt='logo' style={{marginBottom: 12}} />
                    Activities manager
                </Header>
                <Header as='h2' inverted content='Welcome to Activities Manager' />
                <Button as={Link} to='/login' size='huge' inverted>
                    Log in
                </Button>
            </Container>
        </Segment>
    )
}