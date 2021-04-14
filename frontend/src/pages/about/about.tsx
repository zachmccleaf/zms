import React from "react";
import DefaultLayout from "../../layouts/default-layout";
import me from "../../assets/images/me.jpg";

// -----------------------------------------------------------------------------------------
// #region Intefaces
// -----------------------------------------------------------------------------------------

interface AboutPageProps {}

// #endregion Intefaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const AboutPage: React.FC<AboutPageProps> = (props: AboutPageProps) => {
    return (
        <DefaultLayout>
            <div className="p-about">
                <div className="p-about__bio">
                    <h1>hello...</h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Animi veritatis numquam, blanditiis officiis aspernatur beatae doloremque, atque architecto perferendis eligendi earum laboriosam consequuntur assumenda enim ipsa natus alias eius labore.</p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Animi veritatis numquam, blanditiis officiis aspernatur beatae doloremque, atque architecto perferendis eligendi earum laboriosam consequuntur assumenda enim ipsa natus alias eius labore.</p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Animi veritatis numquam, blanditiis officiis aspernatur beatae doloremque, atque architecto perferendis eligendi earum laboriosam consequuntur assumenda enim ipsa natus alias eius labore.</p>
                </div>
            </div>
        </DefaultLayout>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Exports
// -----------------------------------------------------------------------------------------

export default AboutPage;

// #endregion Exports
